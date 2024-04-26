using System.Data;
using DayFw.DataAccess.Helpers;
using Infra.Result;

namespace Infra.Converter
{
    public static class UsuarioPIRepository
    {
        public static UsuarioPi ConvertToUsuarioPI(IDataReader dReader, string nomeProcedure)
        {
            return new UsuarioPi()
            {
                CodUsuario = ConverterHelper.ConvertToInt(dReader, "CodUsuario", nomeProcedure),
                CodTipoUsuario = ConverterHelper.ConvertToInt(dReader, "CodTipoUsuario", nomeProcedure),
                CodTipoAutenticacao = ConverterHelper.ConvertToInt(dReader, "CodTipoAutenticacao", nomeProcedure),
                CodRole = ConverterHelper.ConvertToInt(dReader, "CodRole", nomeProcedure),
                CodExterno = ConverterHelper.ConvertToString(dReader,"CodExterno",nomeProcedure),
                Nome = ConverterHelper.ConvertToString(dReader,"Nome",nomeProcedure),
                Cpf = ConverterHelper.ConvertToString(dReader,"Cpf",nomeProcedure),
                Login = ConverterHelper.ConvertToString(dReader,"Login",nomeProcedure),
                Email = ConverterHelper.ConvertToString(dReader,"Email",nomeProcedure),
                CodAtivo = ConverterHelper.ConvertToBoolean(dReader,"CodAtivo",nomeProcedure)
            };
        }
    }
}