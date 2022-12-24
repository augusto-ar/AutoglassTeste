using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassTeste.Data
{
   public class Notificacao
    {
        public Notificacao()
        {
            Mensagem = new List<string>();
        }

        private List<string> Mensagem { get; set; }
        public bool HasErro => Mensagem !=null && Mensagem.Count > 0;
        public void Adicionar(string texto)
        {
            Mensagem.Add(texto);
        }
        public string MensagemFormata=>FormataMensagem();

        private string FormataMensagem(string separado = "/n")
        {
            return string.Format(String.Join(separado, Mensagem));
        }
    }
}
