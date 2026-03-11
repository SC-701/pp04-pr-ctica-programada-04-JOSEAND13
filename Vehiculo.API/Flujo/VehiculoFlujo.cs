using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{
    public class VehiculoFlujo : IVehiculoFlujo
    {
        private readonly IVehiculoDA _vehiculoDA;
        private readonly IRegistroReglas _registroReglas;
        private readonly IRevisionReglas _revisionReglas;

        public VehiculoFlujo(IVehiculoDA vehiculoDA, IRevisionReglas revisionReglas, IRegistroReglas registroReglas)
        {
            _vehiculoDA = vehiculoDA;         
            _revisionReglas = revisionReglas;
            _registroReglas = registroReglas;
        }

        public async Task <Guid> Agregar(VehiculoRequest vehiculo)
        {
            return await _vehiculoDA.Agregar(vehiculo);
        }

        public async Task <Guid> Editar(Guid id, VehiculoRequest vehiculo)
        {
            return await _vehiculoDA.Editar(id, vehiculo);
        }

        public async Task <Guid> Eliminar(Guid id)
        {
            return await _vehiculoDA.Eliminar(id);
        }

        public async Task <IEnumerable<VehiculoResponse>> Obtener()
        {
            return await _vehiculoDA.Obtener();
        }

        public async Task <VehiculoDetalle> Obtener(Guid id)
        {
            var vehiculo = await _vehiculoDA.Obtener(id);
            vehiculo.registroValido = await _registroReglas.VehiculoEstaRegistrado(vehiculo.placa, vehiculo.correoPropietario);
            vehiculo.revisionValida = await _revisionReglas.RevisionEsValida(vehiculo.placa);
            return vehiculo;
        }
    }
}
