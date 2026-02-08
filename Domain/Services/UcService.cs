using Domain.Interfaces;
using EnergyCom.Domains;
using static EnergyCom.Domains.Uc;

namespace Domain.Services
{
    public class UcService : IUcService
    {
        public Uc CriarUc(int idConsumidor, EnumGrupo grupo, EnumClasse classe, EnumSubClasse subClasse)
        {
            ValidarGrupoClasse(grupo, classe);

            var uc = new Uc
            {
                IdConsumidor = idConsumidor,
                Grupo = grupo,
                Classe = classe,
                SubClasse = subClasse
            };

            return uc;
        }

        public Uc AtualizarUc(Uc uc, int idConsumidor, EnumGrupo grupo, EnumClasse classe, EnumSubClasse subClasse)
        {
            ValidarGrupoClasse(grupo, classe);

            uc.IdConsumidor = idConsumidor;
            uc.Grupo = grupo;
            uc.Classe = classe;
            uc.SubClasse = subClasse;

            return uc;
        }

        private static void ValidarGrupoClasse(EnumGrupo grupo, EnumClasse classe)
        {
            if (!Enum.IsDefined(typeof(EnumGrupo), grupo))
                throw new ArgumentException("Grupo informado é inválido.");

            if (!Enum.IsDefined(typeof(EnumClasse), classe))
                throw new ArgumentException("Classe informada é inválida.");
        }
    }
}
