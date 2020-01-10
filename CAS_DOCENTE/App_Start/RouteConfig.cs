using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CAS_DOCENTE
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 "Vista",
                "Repositorio/Vista/{ID_SEDE}/{ID_CARRERA}/{ID_TIPO_INTERVALO}/{ID_PARALELO}",
                new
                {
                    controller = "Repositorio",
                    action = "Vista",
                    ID_SEDE = UrlParameter.Optional,
                    ID_CARRERA = UrlParameter.Optional,
                    ID_TIPO_INTERVALO = UrlParameter.Optional,
                    ID_PARALELO = UrlParameter.Optional
                });

            routes.MapRoute(
                "Notas",
                "Calificaciones/Nota/{ID_SEDE}/{ID_CARRERA}/{ID_NOTA}/{ID_INTERVALO_DETALLE}",
                new
                {
                    controller = "Calificaciones",
                    action = "Nota",
                    ID_SEDE = UrlParameter.Optional,
                    ID_CARRERA = UrlParameter.Optional,
                    ID_NOTA = UrlParameter.Optional,
                    ID_INTERVALO_DETALLE = UrlParameter.Optional,
                });

            routes.MapRoute(
            "Tareas",
            "Tareas/Crear/{ID_SEDE}/{ID_CARRERA}/{ID_MATERIA}/{ID_PARALELO}/{ID_INTERVALO_DETALLE}",
            new
            {
                controller = "Tareas",
                action = "Crear",
                ID_SEDE = UrlParameter.Optional,
                ID_CARRERA = UrlParameter.Optional,
                ID_MATERIA = UrlParameter.Optional,
                ID_PARALELO = UrlParameter.Optional,
                ID_INTERVALO_DETALLE = UrlParameter.Optional
            });

            routes.MapRoute(
            "DetalleTareas",
            "Tareas/DetalleTareas/{ID_SEDE}/{ID_CARRERA}/{ID_MATERIA}/{ID_PARALELO}/{ID_INTERVALO_DETALLE}",
            new
            {
                controller = "Tareas",
                action = "DetalleTareas",
                ID_SEDE = UrlParameter.Optional,
                ID_CARRERA = UrlParameter.Optional,
                ID_MATERIA = UrlParameter.Optional,
                ID_PARALELO = UrlParameter.Optional,
                ID_INTERVALO_DETALLE = UrlParameter.Optional
            });

            routes.MapRoute(
            "EliminarTareas",
            "Tareas/EliminarTareas/{ID_TAREA}/{ID_SEDE}/{ID_CARRERA}/{ID_MATERIA}/{ID_PARALELO}/{ID_INTERVALO_DETALLE}",
            new
            {
                controller = "Tareas",
                action = "EliminarTareas",
                ID_TAREA= UrlParameter.Optional,
                ID_SEDE = UrlParameter.Optional,
                ID_CARRERA = UrlParameter.Optional,
                ID_MATERIA = UrlParameter.Optional,
                ID_PARALELO = UrlParameter.Optional,
                ID_INTERVALO_DETALLE = UrlParameter.Optional
            });

        }
    }
}
