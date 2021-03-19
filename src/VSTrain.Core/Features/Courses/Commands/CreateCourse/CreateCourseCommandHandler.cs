using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VSTrain.Core.Contracts;
using VSTrain.Core.Contracts.Infrastructure;
using VSTrain.Core.Entities;
using VSTrain.Core.Exceptions;

namespace VSTrain.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ICourseRepository repo;
        private readonly IEmailService emailService;


        public CreateCourseCommandHandler(IMapper mapper, ICourseRepository repo, IEmailService emailService)
        {
            this.emailService = emailService;
            this.mapper = mapper;
            this.repo = repo;
        }

        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var createCourseCommandResponse = new CreateCourseCommandResponse();
            var validator = new CreateCourseCommandValidator(repo);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createCourseCommandResponse.Success = false;
                foreach (var error in validationResult.Errors)
                {
                    createCourseCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCourseCommandResponse.Success)
            {
                var course = mapper.Map<Course>(request);
                var newCourse = await repo.AddAsync(course);
            }
            var email = new Email() { To = "Norton_Geoff@hotmail.com", Subject = "Test Msg", Body = $"Request: {request}", };
            try
            {
                await emailService.SendEmail(email);
            }
            catch (Exception ex) {
                  //ignore
             }
          
  
            return createCourseCommandResponse;
        }
}
}