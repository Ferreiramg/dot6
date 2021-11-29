using System;
namespace Minimal.Models
{
    public record Curso(Guid Id, String nome);
    public record Estudante(Guid Id, String nome, String email, Guid curso, bool graduado, int idade);
}
