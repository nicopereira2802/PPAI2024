using CU_24_GenerarReporte.Boundary;
using CU_24_GenerarReporte.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU_24_GenerarReporte.Controlador
{
     
    public class Gestor
    {
        //static PantallaPrincipal principalNueva;
        public List<Vino> ListaVinos { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string TipoReseña { get; set; }
        public string TipoVisualizacion { get; set; }

        private PantallaPrincipal pantallaPrincipalAtributo;

        List<(string, decimal, string, string, string, List<string>)> listaVinosValidados = new List<(string, decimal, string, string, string, List<string>)>();

        public Gestor(List<Vino> listaVinos, DateTime fechaDesde, DateTime fechaHasta, string tipoReseña, string tipoVisualizacion, PantallaPrincipal principal)
        {
            ListaVinos = listaVinos;
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
            TipoReseña = tipoReseña;
            TipoVisualizacion = tipoVisualizacion;
            pantallaPrincipalAtributo = principal;
        }


       
        // Implementación de métodos adicionales si es necesario
        public void OpcionGenerarRankingVinos()
        {
            pantallaPrincipalAtributo.SolicitarSelFechaDesdeYHasta();
        }
        public void TomarSelFechaDesdeYHasta(DateTime fechaDesde, DateTime fechaHasta)
        {
            this.FechaDesde = fechaDesde;
            this.FechaHasta = fechaHasta;

            pantallaPrincipalAtributo.SolicitarSelTipoReseña();
        }
        public void TomarSeleccionTipoReseña(string tipoReseña)
        {
            this.TipoReseña = tipoReseña;

        }
        public void TomarSelTipoVisualizacion(string tipoVisualizacion)
        {
            this.TipoVisualizacion = tipoVisualizacion;

            pantallaPrincipalAtributo.SolicitarConfirmacionGenReporte();
        }

        public void TomarConfirmacionGenReporte()
        {
            BuscarVinosConReseñaEnPeriodos();
        }
        public void BuscarVinosConReseñaEnPeriodos()

        {
            List<Vino> vinosAgregados = new List<Vino>();


            List<> listaVinosValidados = new List<(string, decimal, string, string, string, List<string>)>();
            List<Vino> listaDeObjetosVino = new List<Vino>();

            foreach (Vino vino in ListaVinos)
            {
                Vino vinoConSommelierYPeriodo = vino.tenesReseñasDeTipoEnPeriodo(vino, FechaDesde, FechaHasta);
                if (vinoConSommelierYPeriodo != null)
                {
                    vinosAgregados.Add(vinoConSommelierYPeriodo);
                }
                
            }
            foreach (Vino vinoValidado in vinosAgregados)
            {
                string nombreVino = vinoValidado.Nombre;
                decimal precioVino = vinoValidado.PrecioARS;
                string nombreBodega = vinoValidado.Bodega.Nombre;
                string nombreRegion = vinoValidado.Bodega.obtenerRegion();
                string nombrePais = vinoValidado.Bodega.obtenerPais();
                List<string> listaDescVarietales = vinoValidado.buscarDescripcionDeVarietal();
                (string, decimal, string, string, string, List<string>) tuplaDatosVinoValidado = (nombreVino, precioVino, nombreBodega, nombreRegion, nombrePais, listaDescVarietales);
                listaVinosValidados.Add(tuplaDatosVinoValidado);
            }
            calcularPuntajeDeSommelierEnPeriodo(listaVinosValidados);

        }

        public void calcularPuntajeDeSommelierEnPeriodo(List<(string, decimal, string, string, string, List<string>)>  listaVinosValidados)
        {
            foreach (Object objeto in listaVinosValidados)
            {
                o
            }
        }
        public void SolicitarSelFechaDesdeYHasta()
        {

        }

        
    }

}
