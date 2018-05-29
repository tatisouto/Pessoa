using AutoMapper;
using Projeto.Agenda.Application.Interface;
using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Agenda.MVC.Controllers
{
    public class PessoaController : Controller
    {

        private readonly IPessoaAppService _pessoaApp;

        public PessoaController(IPessoaAppService pessoaApp)
        {
            _pessoaApp = pessoaApp;
        }
        // GET: Pessoa
        public ActionResult Index()
        {
            var pessoaViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaApp.GetAll());
            return View(pessoaViewModel.ToList().OrderBy(x => x.Nome));
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(Guid id)
        {
            var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaApp.GetById(id));
            return View(pessoaViewModel);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(PessoaViewModel objPessoa)
        {
            try
            {


                CustomValidate("Cpf", objPessoa.Cpf);
                CustomValidate("Email", objPessoa.Email);

                if (ModelState.IsValid)
                {

                    var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(objPessoa);
                    _pessoaApp.Add(pessoa);

                    return Json(new { success = true, responseText = "Salvo com sucesso." }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var ListaErros = new List<string>();
                    foreach (var values in ModelState.Values)
                    {
                        foreach (var erros in values.Errors)
                        {
                            ListaErros.Add(erros.ErrorMessage);
                        }
                    }
                    return Json(new { success = false, responseText = ListaErros }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    responseText = ex.Message
                }, JsonRequestBehavior.AllowGet);

            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(Guid id)
        {
            var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaApp.GetById(id));
            return View(pessoaViewModel);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaViewModel objPessoa)
        {
            try
            {
                CustomValidate("Email", objPessoa.Email);
                CustomValidate("DataNascimento", objPessoa.DtNascimento.ToString());


                if (ModelState.IsValid)
                {
                    var pessoaDomain = Mapper.Map<PessoaViewModel, Pessoa>(objPessoa);
                    _pessoaApp.Update(pessoaDomain);

                    return Json(new { success = true, responseText = "Salvo com sucesso." }, JsonRequestBehavior.AllowGet);


                }
                else
                {
                    var ListaErros = new List<string>();
                    foreach (var values in ModelState.Values)
                    {
                        foreach (var erros in values.Errors)
                        {
                            ListaErros.Add(erros.ErrorMessage);
                        }
                    }
                    return Json(new { success = false, responseText = ListaErros }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Contate administrador" }, JsonRequestBehavior.AllowGet);

            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(Guid id)
        {
            var pessoa = _pessoaApp.GetById(id);
            _pessoaApp.Remove(pessoa);


            return RedirectToAction("Index");



        }
        /// <summary>
        /// Customizar erros ModelState
        /// </summary>
        /// <param name="objPessoa"></param>
        /// <param name="value"></param>
        public void CustomValidate(string objPessoa, string value)
        {

            switch (objPessoa)
            {

                case "Nome":
                    if (string.IsNullOrEmpty(value))
                        ModelState.AddModelError("Nome", "Campo nome é obrigatório.");
                    break;


                case "Email":
                    if (!Regex.Match(value, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").Success)
                        ModelState.AddModelError("Email", "E-mail inválido.");


                    break;

                case "Cpf":

                    if (ExistsCpf(value))
                    {
                        ModelState.AddModelError("Cpf", "Cpf já cadastrado.");

                    }
                    else
                    {
                        if (!IsCpf(value))
                        {
                            ModelState.AddModelError("Cpf", "Cpf inválido.");

                        }
                    }
                    break;



                case "DataNascimento":
                    var birthdate = Convert.ToDateTime(value);
                    var today = DateTime.Today;
                    var age = today.Year - birthdate.Year;
                    if (birthdate.Year >= today.Year)
                    {
                        ModelState.AddModelError("DataNascimento", "Data Nascimento Inválida.");
                        break;
                    }


                    if (birthdate < today.AddYears(-age))
                    {
                        age--;
                        ModelState.AddModelError("DataNascimento", "Não é permitido cadastro de menor de 18 anos.");
                    }
                    break;

                default:
                    break;
            }


        }

        /// <summary>
        /// Valida CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            if (cpf == "00000000000" ||
           cpf == "11111111111" ||
           cpf == "22222222222" ||
           cpf == "33333333333" ||
           cpf == "44444444444" ||
           cpf == "55555555555" ||
           cpf == "66666666666" ||
           cpf == "77777777777" ||
           cpf == "88888888888" ||
           cpf == "99999999999")
                return false;












            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Verificar se cpf já está cadastrado.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public bool ExistsCpf(string cpf)
        {
            try
            {

                var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaApp.GetPessoaByCpf(cpf));

                if (pessoaViewModel != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}


