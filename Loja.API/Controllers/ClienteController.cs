using Loja.API.Contexts;
using Loja.API.Models.Loja;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("ApiCorsPolicy")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("Obter")]
        public IActionResult Obter()
        {
            var contextoLoja = new LojaContext();
            var clientelista = contextoLoja.Clientes.ToList();
            return Ok(clientelista);
        }

        [HttpGet]
        [Route("Obter1")]
        public IActionResult Obter1(int id)
        {
            var contextoLoja = new LojaContext();
            var clientelista = contextoLoja.Clientes.Where(cliente => cliente.Id == id).FirstOrDefault();
            return Ok(clientelista);
        }

        [HttpPost]
        [Route("Salvar")]
        public IActionResult Salvar([FromBody] Cliente cliente)
        {
            var contextoLoja = new LojaContext();
            if (cliente.Id > 0)
            {
                //editar
                //Poderia usar Linq ou Lambda
                var clienteEditar = contextoLoja.Clientes.Where(clienteW => clienteW.Id == cliente.Id).FirstOrDefault();
                if (clienteEditar != null)
                {
                    //poderia usar também o AutoMapper
                    clienteEditar.Nome = cliente.Nome;
                    clienteEditar.Fone = cliente.Fone;
                }
            }
            else
            {
                //salvar um novo cliente
                contextoLoja.Clientes.Add(cliente);
            }

            contextoLoja.SaveChanges();

            return Ok("Cliente salvo com sucesso");
        }

        [HttpGet]
        [Route("Deletar")]
        public IActionResult Deletar(int id)
        {
            var contextoLoja = new LojaContext();
            var clienteDeletar = contextoLoja.Clientes.Where(clienteW => clienteW.Id == id).FirstOrDefault();
            contextoLoja.Clientes.Remove(clienteDeletar);
            contextoLoja.SaveChanges();
            return Ok("Cliente deleteado com sucesso");
        }
    }
}
