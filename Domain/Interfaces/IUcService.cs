using EnergyCom.Domains;
using static EnergyCom.Domains.Uc;

namespace Domain.Interfaces
{
    public interface IUcService
    {
        Uc CriarUc(int idConsumidor, EnumGrupo grupo, EnumClasse classe, EnumSubClasse subClasse);
        Uc AtualizarUc(Uc uc, int idConsumidor, EnumGrupo grupo, EnumClasse classe, EnumSubClasse subClasse);
    }
}
