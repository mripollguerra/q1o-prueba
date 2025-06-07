using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.RegistrationSubject.Commands.RegistrationSubject;

public class RegistrationSubjectCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<RegistrationSubjectCommand, RegistrationSubjectCommandResponse>
{
    public async Task<RegistrationSubjectCommandResponse> HandleAsync(RegistrationSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var isSubjectAlreadyRegistered =
            await unitOfWork.RegistrationSubjectRepository.IsSubjectAlreadyRegisteredAsync(
                command.RegistrationSubject.StudentId, command.RegistrationSubject.SubjectId);
        if (isSubjectAlreadyRegistered)
            return new RegistrationSubjectCommandResponse(false, "El estudiante ya tiene esta materia inscrita.");

        var canRegisterSubject =
            await unitOfWork.RegistrationSubjectRepository.CanRegisterSubjectByStudentIdAsync(
                command.RegistrationSubject.StudentId);

        if (canRegisterSubject)
            return new RegistrationSubjectCommandResponse(false,
                "No se permite inscribir más de 3 materias con más de 4 créditos.");

        var registrationResponse = await unitOfWork.RegistrationSubjectRepository.AddAsync(command.RegistrationSubject);
        var isRegistrationSuccessful = registrationResponse > 0;

        return new RegistrationSubjectCommandResponse(
            isRegistrationSuccessful,
            isRegistrationSuccessful
                ? "La materia fue registrada exitosamente."
                : "Ocurrió un error al registrar la materia. Por favor, inténtalo nuevamente."
        );
    }
}