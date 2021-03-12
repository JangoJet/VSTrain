using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using VSTrain.Core.Contracts;
using VSTrain.Core.Entities;

namespace VSTrain.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        private readonly ICourseRepository repo;
        public CreateCourseCommandValidator(ICourseRepository repo)
        {
            this.repo = repo;
            RuleFor(course => course.Name)
                .NotEmpty().WithMessage($"{nameof(Course)} name is required")
                .NotNull().WithMessage($"{nameof(Course)} name is required")
                .MaximumLength(50).WithMessage($"{nameof(Course)} name must be no more than 50 characters");

            RuleFor(course => course.date)
                .LessThan(DateTimeOffset.Now)
                .WithMessage("The date must not be in the future");

            RuleFor(course => course)
                .MustAsync(CourseNameIsUnique)
                .WithMessage($"{nameof(Course)} must be unique");
        }

        private async Task<bool> CourseNameIsUnique(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            return !(await repo.CourseNameIsUnique(request.Name));
        }
    }
}