using FluentValidation;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Validators
{
    public class TaskValidator : AbstractValidator<TaskManagementSystem.Model.Task>
    {
        public TaskValidator()
        {
            RuleFor(p => p.Name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Id).Cascade(CascadeMode.StopOnFirstFailure).NotNull().WithMessage("{PropertyName} should be not empty. NEVER!");

            RuleFor(p => p.Status).Cascade(CascadeMode.StopOnFirstFailure).NotNull().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Status)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must((s) => { return Enum.IsDefined(typeof(Statuses), s); })
                .WithMessage("Wrong task status code");

            RuleFor(p => p.CreatorId).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("{PropertyName} should be not empty. NEVER!")
                .DependentRules(() =>
                {
                    RuleFor(p => p)
                        .Cascade(CascadeMode.StopOnFirstFailure)
                        .Must(CheckIfCreatorExists).WithMessage("Creator doesn't exist for this Id")
                        .Must(CheckIfPerformerIdExists).WithMessage("Performer doesn't exist for this Id")
                        .Must(CheckRoleValidity).WithMessage("Incorrect Creator - Performer relation!")
                        .Must(CheckPerformer).WithMessage("Teamleader should be not a performer!");
                });
        }

        public bool CheckIfCreatorExists(TaskManagementSystem.Model.Task task)
        {
            using (var db = new TaskManagementContext())
            {
                User creator = db.Users.FirstOrDefault(t => t.Id == task.CreatorId);
                if (creator == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool CheckIfPerformerIdExists(TaskManagementSystem.Model.Task task)
        {
            using (var db = new TaskManagementContext())
            {
                //If performerId is null, then let it pass, we only need to make sure that
                //if there is an Id it has to be valid
                if (task.PerformerId == null)
                {
                    return true;
                }

                User performer = db.Users.FirstOrDefault(t => t.Id == task.PerformerId);
                if (performer == null)
                {
                    return false;
                }

                return true;
            }
        }

        public bool CheckRoleValidity(TaskManagementSystem.Model.Task task)
        {
            using (var db = new TaskManagementContext())
            {
                User creator = db.Users.FirstOrDefault(t => t.Id == task.CreatorId);
                string creatorRole = db.Roles.FirstOrDefault(t => t.Id == creator.RoleID).Name;

                //Performer doesn't have to exist, so we return true of creatorRole is allowed.
                if (task.PerformerId == null && creatorRole != "Junior")
                {
                    return true;
                }
                else if (creatorRole == "Junior")
                {
                    return false;
                }

                User performer = db.Users.FirstOrDefault(t => t.Id == task.PerformerId);
                string performerRole = db.Roles.FirstOrDefault(t => t.Id == performer.RoleID).Name;

                //Check creator and performer relation
                bool isRelationValid = false;

                if (creatorRole == "TeamLead" && (performerRole == "Senior" || performerRole == "Middle"))
                {
                    isRelationValid = true;
                }
                else if (creatorRole == "Senior" && (performerRole == "Middle" || performerRole == "Junior"))
                {
                    isRelationValid = true;
                }
                else if (creatorRole == "Middle" && performerRole == "Junior")
                {
                    isRelationValid = true;
                }

                return isRelationValid;
            }
        }

        public bool CheckPerformer(TaskManagementSystem.Model.Task task)
        {
            using (var db = new TaskManagementContext())
            {
                if (task.PerformerId == null)
                {
                    return true;
                }

                User performer = db.Users.FirstOrDefault(t => t.Id == task.PerformerId);
                string performerRole = db.Roles.FirstOrDefault(t => t.Id == performer.RoleID).Name;

                if (performerRole == "TeamLead")
                {
                    return false;
                }
                if (performerRole == "Junior")
                {
                    task.Status = Statuses.Completed;
                }

                return true;
            }
        }
    }
}