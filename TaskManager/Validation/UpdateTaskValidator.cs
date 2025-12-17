using FluentValidation;

namespace TaskManager.Validation
{
    public class UpdateTaskValidator : AbstractValidator<DTO.TaskUpdateDto>
    {
        public UpdateTaskValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("El título es obligatorio")
               .MaximumLength(80).WithMessage("El título no puede exceder 80 caracteres");

            RuleFor(x => x.Status).Must(status => {
                if (status < 0 || (int)status > 2)
                {
                    return false;
                }

                return true;
            }).WithMessage("The status must be 0=Pending, 1=InProgress, 2=Completed");
        }
    }
}
