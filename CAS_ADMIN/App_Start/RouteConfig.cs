using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CAS_ADMIN
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
                 "RepositorioDocenteVista",
                "Docente/RepositorioDocenteVista/{ID_SEDE}/{ID_CARRERA}/{ID_TIPO_INTERVALO}/{ID_PARALELO}",
                new
                {
                    controller = "Docente",
                    action = "RepositorioDocenteVista",
                    ID_SEDE = UrlParameter.Optional,
                    ID_CARRERA = UrlParameter.Optional,
                    ID_TIPO_INTERVALO = UrlParameter.Optional,
                    ID_PARALELO = UrlParameter.Optional
                });

            routes.MapRoute(
                "NotasDocente",
                "Docente/NotasDocenteVista/{ID_SEDE}/{ID_CARRERA}/{ID_NOTA}/{ID_INTERVALO_DETALLE}/{ID_DOCENTE}",
                new
                {
                    controller = "Docente",
                    action = "NotasDocenteVista",
                    ID_SEDE = UrlParameter.Optional,
                    ID_CARRERA = UrlParameter.Optional,
                    ID_NOTA = UrlParameter.Optional,
                    ID_INTERVALO_DETALLE = UrlParameter.Optional,
                    ID_DOCENTE = UrlParameter.Optional
                });

            routes.MapRoute(
                "ImprimirNotaDocente",
                "Docente/ImprimirNotaDocente/{ID_SEDE}/{ID_CARRERA}/{ID_NOTA}/{ID_INTERVALO_DETALLE}/{ID_DOCENTE}",
                new
                {
                    controller = "Docente",
                    action = "ImprimirNotaDocente",
                    ID_SEDE = UrlParameter.Optional,
                    ID_CARRERA = UrlParameter.Optional,
                    ID_NOTA = UrlParameter.Optional,
                    ID_INTERVALO_DETALLE = UrlParameter.Optional,
                    ID_DOCENTE = UrlParameter.Optional
                });


            routes.MapRoute(
            "HorarioDetalle",
            "HorarioDetalle/HorarioDetalleMateria/{ID_PARALELO_MATERIA}/{ID_SEDE}",
            new
            {
                controller = "HorarioDetalle",
                action = "HorarioDetalleMateria",
                ID_PARALELO_MATERIA = UrlParameter.Optional,
                ID_SEDE = UrlParameter.Optional
            });
        }
    }
}
