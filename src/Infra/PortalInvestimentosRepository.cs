using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using DayFw.DataAccess.Interfaces;
using Infra.Converter;
using Infra.Entidade;
using Infra.Result;
using Infra.Signature;

namespace Infra
{
    public class PortalInvestimentosRepository : BaseRepositoryAdo, IPortalInvestimentoRepository
    {
        public PortalInvestimentosRepository() : base(new DcvPortalInvestimentosParameters())
        {
            
        }

        public async Task<IList<UsuarioPi>> ObterListaUsuarioAsync()
        {
            
            var parametros = new List<SqlParameter>(0);
           
            var execute = new CreateExecuteAdo()     
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_LISTA_USUARIOS_PI");

            return await ExecuteListAsync<UsuarioPi>(execute);
        }

        public async Task<IList<TipoAutenticacao>> ObterListaTipoAutenticacaoAsync()
        {
            var parametros = new List<SqlParameter>(0);
           
            var execute = new CreateExecuteAdo()     
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_LISTA_TIPO_AUTENTICACAO_PI");

            return await ExecuteListAsync<TipoAutenticacao>(execute);
        }

        public async Task<IList<TipoUsuario>> ObterListaTipoUsuarioAsync()
        {
            var parametros = new List<SqlParameter>(0);
           
            var execute = new CreateExecuteAdo()     
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_LISTA_TIPO_USUARIOS_PI");

            return await ExecuteListAsync<TipoUsuario>(execute);
        }

        public async Task<UsuarioPi> ObterUsuarioPorCodigoUsuarioAsync(int CodUsuario)
        {
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@CodUsuario",SqlDbType.Int){Value = CodUsuario});
            
            var execute = new CreateExecuteAdo()     
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_USUARIOS_PI_POR_CODIGO_USUARIO");

            return await ExecuteObjectAsync(execute , UsuarioPIRepository.ConvertToUsuarioPI);
        }

        public async Task<int> AtualizarUsuarioAsync(EditarUSuarioRepositorySignature signature)
        {
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@CodigoUsuario",SqlDbType.Int){Value = signature.CodUsuario});
            parametros.Add(new SqlParameter("@CodigoExterno",SqlDbType.VarChar){Value = signature.CodExterno});
            parametros.Add(new SqlParameter("@Nome",SqlDbType.VarChar){Value = signature.Nome});
            parametros.Add(new SqlParameter("@Cpf",SqlDbType.VarChar){Value = signature.Cpf});
            parametros.Add(new SqlParameter("@Ativo",SqlDbType.Bit){Value = signature.Ativo });
            
            var execute = new CreateExecuteAdo()     
                .WithParameters(parametros)
                .WithProcedure("P_ATUALIZAR_USUARIOS_PI");

            return await ExecuteNonQueryAsync(execute);
        }

        public async Task<Infotreasury> ObterDataGiroInfotreasury()
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_DATA_GIRO");

            return await ExecuteObjectAsync<Infotreasury>(execute);
        }

        public async Task<IList<Ambiente>> ObterAmbientesPI()
        {
            try
            {
                var execute = new CreateExecuteAdo()
                    .WithProcedure("P_OBTER_AMBIENTES_POR_SISTEMA");

                return await ExecuteListAsync<Ambiente>(execute);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task AtualizarAmbientesPI(EditarAmbienteRepositorySignature signature)
        {
            try
            {
                var parametros = new List<SqlParameter>(0);

                parametros.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = signature.Id });
                parametros.Add(new SqlParameter("@NumeroChamado", SqlDbType.VarChar) { Value = signature.NumeroChamado });
                parametros.Add(new SqlParameter("@Descricao", SqlDbType.VarChar) { Value = signature.Descricao });
                parametros.Add(new SqlParameter("@DevId", SqlDbType.Int) { Value = signature.DevId });
                parametros.Add(new SqlParameter("@NegId", SqlDbType.Int) { Value = signature.NegId });
                parametros.Add(new SqlParameter("@SitId", SqlDbType.Int) { Value = signature.SitId });
                parametros.Add(new SqlParameter("@SisId", SqlDbType.Int) { Value = signature.SisId });
                parametros.Add(new SqlParameter("@Dependencia", SqlDbType.VarChar) { Value = signature.Dependencia });

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_ATUALIZAR_AMBIENTE_POR_SISTEMA");

                await ExecuteListAsync<Ambiente>(execute);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public async Task AtualizarAmbientesPIQa(EditarAmbienteQaRepositorySignature signature)
        {
            try
            {
                var parametros = new List<SqlParameter>(0);

                parametros.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = signature.AmbienteId });
                parametros.Add(new SqlParameter("@Nome", SqlDbType.VarChar) { Value = signature.Release });
                parametros.Add(new SqlParameter("@Requisicao", SqlDbType.VarChar) { Value = signature.Requisicao });
                parametros.Add(new SqlParameter("@DesenvolvedorId", SqlDbType.Int) { Value = signature.DevId });
                parametros.Add(new SqlParameter("@NegocioId", SqlDbType.Int) { Value = signature.NegId });
                parametros.Add(new SqlParameter("@DataImplantacao", SqlDbType.DateTime) { Value = signature.DataImplatacao });               

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_AtualizarAmbienteQa");

                await ExecuteNonQueryAsync(execute);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IList<Desenvolvedor>> ObterDesenvolvedoresPI()
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_DESENVOLVEDOR");

            return await ExecuteListAsync<Desenvolvedor>(execute);
        }

        public async Task<IList<Sistema>> ObterSistemas()
            
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_SISTEMAS");

            return await ExecuteListAsync<Sistema>(execute);
        }


        public async Task<IList<Negocio>> ObterNegocioPI()
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_NEGOCIO");

            return await ExecuteListAsync<Negocio>(execute);
        }

        public async Task<AmbienteQa> ObterAmbientesPIQa()
        {
            var execute = new CreateExecuteAdo()                
                .WithProcedure("P_OBTER_AMBIENTE_QA_POR_SISTEMA");

            return await ExecuteObjectAsync<AmbienteQa>(execute);
        }

        public async Task<IList<Pacote>> ObterListaPacoteQa()
        {
            var execute = new CreateExecuteAdo()
                .WithProcedure("P_OBTER_PACOTE_QA_POR_SISTEMA");

            return await ExecuteListAsync<Pacote>(execute);
        } 

        public async Task<Perfil> ObterPerfilPorCodCliente(PerfilRepositorySignature signature)
        {
                var parametros = new List<SqlParameter>(0);
                parametros.Add(new SqlParameter("@CodCliente", SqlDbType.VarChar) { Value = signature.CodCliente });

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_CONSULTAR_PERFIL_CLIENTES_SUITABILITY_MARCO");

                return await ExecuteObjectAsync<Perfil>(execute);
        }

        public async Task<IList<AmbienteStatus>> ObterStatus()
        {
            var parametros = new List<SqlParameter>(0);

            var execute = new CreateExecuteAdo()
                .WithParameters(parametros)
                .WithProcedure("P_OBTER_AMBIENTE_STATUS");

            return await ExecuteListAsync<AmbienteStatus>(execute);
        }

        public async Task AtualizarAmbientesNovoPIQa(EditarAmbienteQaRepositorySignature signature)
        {
            try
            {
                var parametros = new List<SqlParameter>(0);

                parametros.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = signature.AmbienteId });
                parametros.Add(new SqlParameter("@Nome", SqlDbType.VarChar) { Value = signature.Release });
                parametros.Add(new SqlParameter("@Requisicao", SqlDbType.VarChar) { Value = signature.Requisicao });
                parametros.Add(new SqlParameter("@DesenvolvedorId", SqlDbType.Int) { Value = signature.DevId });
                parametros.Add(new SqlParameter("@NegocioId", SqlDbType.Int) { Value = signature.NegId });
                parametros.Add(new SqlParameter("@DataImplantacao", SqlDbType.DateTime) { Value = signature.DataImplatacao });

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_AtualizarAmbienteNovoQa");

                await ExecuteNonQueryAsync(execute);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public Task IncluirChamadosQa(List<PacoteRepositorySignature> signature)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizarChamadosQa(PacoteRepositorySignature signature)
        {
            try
            {
                var parametros = new List<SqlParameter>(0);

                parametros.Add(new SqlParameter("@ReleaseId", SqlDbType.Int) { Value = signature.ReleaseId });
                parametros.Add(new SqlParameter("@Branch", SqlDbType.VarChar) { Value = signature.Branch });
                parametros.Add(new SqlParameter("@ChamadoId", SqlDbType.VarChar) { Value = signature.ChamadoId });
                parametros.Add(new SqlParameter("@NegocioId", SqlDbType.Int) { Value = signature.NegocioTesteId });
                parametros.Add(new SqlParameter("@SituacaoId", SqlDbType.Int) { Value = signature.SituacaoId });
                parametros.Add(new SqlParameter("@Dependencia", SqlDbType.VarChar) { Value = signature.Dependencia });

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_AtualizarAmbientePacoteNovoQa");

                await ExecuteNonQueryAsync(execute);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task ExcluirFeatureAmbiente(int chamadoId)
        {
            try
            {
                var parametros = new List<SqlParameter>(0);

                parametros.Add(new SqlParameter("@ChamadoId", SqlDbType.Int) { Value =chamadoId });
               
                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_ExcluirFeatureAmbiente");

                await ExecuteNonQueryAsync(execute);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task AtualizarChamadoAmbienteQa(ChamadoAmbienteQaRepositorio signature)
        {
            try
            {
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@ChamadoId", SqlDbType.Int) { Value = signature.ChamadoId });
                parametros.Add(new SqlParameter("@NegocioTesteId", SqlDbType.VarChar) { Value = signature.NegocioTesteId });
                parametros.Add(new SqlParameter("@SituacaoId", SqlDbType.VarChar) { Value = signature.SituacaoId });

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_ATUALIZAR_CHAMADO_AMBIENTE_PI");

                await ExecuteNonQueryAsync(execute);
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public async Task LiberarChamadoAmbientesQa(LiberarAmbienteRespositorySignature liberarAmbienteRespositorySignature)
        {
            try
            {
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = liberarAmbienteRespositorySignature.Id});

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_Liberar_Ambiente_Qa");
                await ExecuteNonQueryAsync(execute);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AdicionarAmbiente()
        {
            try
            {
                var parametros = new List<SqlParameter>();

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_INSERIR_AMBIENTE_PADRAO");
                var retorno  = await ExecuteNonQueryAsync(execute);

                return retorno > 0 ? true : false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirAmbiente(ExcluirAmbienteRepositorySignature signature)
        {
            try
            {
                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = signature.Id });

                var execute = new CreateExecuteAdo()
                    .WithParameters(parametros)
                    .WithProcedure("P_EXCLUIR_AMBIENTE_PADRAO");
                var retorno = await ExecuteNonQueryAsync(execute);

                return retorno > 0 ? true : false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}