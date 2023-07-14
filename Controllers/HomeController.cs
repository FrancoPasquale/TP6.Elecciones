using Microsoft.AspNetCore.Mvc;

namespace TP6.Elecciones.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(){
        ViewBag.NomsPartido = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido){
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato){
        ViewBag.Candidato = BD.VerInfoCandidato(idCandidato);
        
        return View("DetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido){
        ViewBag.idPartido = idPartido;
        return View("formulario");
    }
    [HttpPost] public IActionResult GuardarCandidato(Candidato can){
        BD.AgregarCandidato(can);
        
        return RedirectToAction("VerDetallePartido",new{idPartido=can.FkPartido});
    }                                         
    public IActionResult EliminarCandidato(int idCandidato, int idPartido){
        BD.EliminarCandidato(idCandidato);    
        return View("DetallePartido");
    }
    public IActionResult Elecciones(){
        return View("InfoVota");
    }
    public IActionResult Creditos(){
        return View("Creditos");
    }
}
