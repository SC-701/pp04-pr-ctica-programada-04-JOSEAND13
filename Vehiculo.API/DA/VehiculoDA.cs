using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class VehiculoDA : IVehiculoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new 
            {
                id = Guid.NewGuid(),
                idmodelo = vehiculo.Idmodelo,
                placa = vehiculo.placa,
                color = vehiculo.color,
                anio = vehiculo.anio,
                precio = vehiculo.precio,
                correoPropietario = vehiculo.correoPropietario,
                telefonoPropietario = vehiculo.telefonoPropietario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid id, VehiculoRequest vehiculo)
        {
            await VerificarVehiculoExiste(id);

            string query = @"EditarVehiculo";          
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = id,
                idmodelo = vehiculo.Idmodelo,
                placa = vehiculo.placa,
                color = vehiculo.color,
                anio = vehiculo.anio,
                precio = vehiculo.precio,
                correoPropietario = vehiculo.correoPropietario,
                telefonoPropietario = vehiculo.telefonoPropietario
            });
            return resultadoConsulta;
        }
       
        public async Task<Guid> Eliminar(Guid id)
        {
            await VerificarVehiculoExiste(id);

            string query = @"EliminarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id =id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query);

            return resultadoConsulta;
        }

        public async Task<VehiculoDetalle> Obtener(Guid id)
        {
            string query = @"ObtenerVehiculo";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(query,
                new { id = id });

            return resultadoConsulta.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task VerificarVehiculoExiste(Guid id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(id);

            if (resultadoConsultaVehiculo == null)
            {
                throw new Exception("No se encontró el vehículo");
            }
        }
        #endregion
    }
}
