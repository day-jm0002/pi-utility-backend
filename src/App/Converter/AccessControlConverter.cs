using System.Collections.Generic;
using App.Result;
using Proxy.AccessControl.Response;

namespace App.Converter
{
    public static class AccessControlConverter
    {
        public static List<RoleResult>  RoleResultProxyToRoleResul(List<RoleResultProxy> role)
        {
            var listaRoleResult = new List<RoleResult>();
            foreach (var item in role)
            {
                var roleResult = new RoleResult();
                roleResult.CodigoRole = item.CodigoRole;
                roleResult.CodigoSistema = item.CodigoSistema;
                roleResult.Nome = item.Nome;
                roleResult.Descricao = item.Descricao;
                roleResult.Ativo = item.Ativo;

                listaRoleResult.Add(roleResult);
            }

            return listaRoleResult;

        }
    }
}