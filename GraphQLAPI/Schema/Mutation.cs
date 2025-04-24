using AppAny.HotChocolate.FluentValidation;
using Microsoft.AspNetCore.Authorization;
using School.API.Validators;
using School.Core.DTOs;
using School.Core.Interfaces;
using School.Core.Models.Authentication;
using School.Core.Models.Authorization;
using School.Infrastructure.Repositories;

namespace School.API.Schema
{
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Mutation(CoursesRepository coursesRepository, IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _coursesRepository = coursesRepository;
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Admin")]
        public async Task<CourseResult> CreateCourse(
                [UseFluentValidation,UseValidator<CourseTypeInputValidator>]CourseTypeInput courseInput,
                [Service] IHttpContextAccessor httpContextAccessor)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new Exception("User not authenticated.");

            CourseDTO course = new CourseDTO()
            {
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId,
                CreatedBy = userId // Add this field to track who created it
            };

            CourseDTO createdCourse = await _coursesRepository.Create(course);

            return new CourseResult()
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name,
                Subject = createdCourse.Subject,
                InstructorId = createdCourse.InstructorId,
                CreatedBy = createdCourse.CreatedBy // Add this field to track who created it
            };
        }

        [Authorize(Roles = "Admin")]
        public async Task<CourseResult> UpdateCourse(Guid id,CourseTypeInput courseInput)
        {
            CourseDTO course = new CourseDTO()
            {
                Id = id,
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            CourseDTO updatedCourse = await _coursesRepository.Update(course);

            return new CourseResult()
            {
                Id = updatedCourse.Id,
                Name = updatedCourse.Name,
                Subject = updatedCourse.Subject,
                InstructorId = updatedCourse.InstructorId
            };
        }

        [Authorize(Roles = "Admin")]
        public async Task<bool> DeleteCourse(Guid id)
        {
            try
            {

            return await _coursesRepository.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<AuthModel> Register(RegisterModel input)
        => await _authService.RegisterAsync(input);

        public async Task<AuthResult> Login(TokenRequestModel input)
            => await _authService.GetTokenAsync(input);


        [Authorize(Roles = "Admin")]
        public async Task<string> AddRole(AddRoleModel input)
            => await _authService.AddRoleAsync(input);

    }
}
