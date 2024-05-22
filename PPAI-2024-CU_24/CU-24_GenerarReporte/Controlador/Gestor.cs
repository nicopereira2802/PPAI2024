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
            List<string> nombreVinosAgregados = new List<string>();
            List<decimal> precioVinosAgregados = new List<decimal>();
            List<string> nombreBodegaAgregados = new List<string>();
            List<List<string>> listaRegionPais = new List<List<string>>();
            List<List<string>> listaVarietales = new List<List<string>>();
            List<List<Object>> listaVinosConDatos = new List<List<Object>>();

            foreach (Vino vino in ListaVinos)
            {
                Vino vinoConSommelierYPeriodo = vino.tenesReseñasDeTipoEnPeriodo(vino,FechaDesde,FechaHasta);
                if (vinoConSommelierYPeriodo != null)
                {
                    vinosAgregados.Add(vinoConSommelierYPeriodo);
                    nombreVinosAgregados.Add(vinoConSommelierYPeriodo.Nombre);
                    precioVinosAgregados.Add(vinoConSommelierYPeriodo.PrecioARS);
                    nombreBodegaAgregados.Add(vinoConSommelierYPeriodo.Bodega.Nombre);
                    listaRegionPais.Add(vinoConSommelierYPeriodo.Bodega.obtenerRegionYPais());
                    listaVarietales.Add(vinoConSommelierYPeriodo.buscaVarietal());
                    
                }
            }
            vinosAgregados = vinosAgregados;
            nombreVinosAgregados = nombreVinosAgregados;
            nombreBodegaAgregados = nombreBodegaAgregados;
            listaRegionPais = listaRegionPais;
            listaVarietales = listaVarietales;


        }

        public void SolicitarSelFechaDesdeYHasta()
        {

        }

        
    }

}
