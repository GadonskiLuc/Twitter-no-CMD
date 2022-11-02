using System.Text.RegularExpressions;
class Sistema{
    private Interface tela;
    private string usrName;
    private string pWord;
    private string name;
    private string birth;
    private List<Conta> Dados = new List<Conta>();
    private string op;
    private string msg;
    private string priv;
    private int posConta = 0;

    public Sistema (Interface tela){
        this.tela = tela;
        this.Dados.Add(new Conta("lucas matheus","luc","123","30/06/2004"));
    }

    public void cadastroConta(){
        while(true){
            tela.telaLogin();
            
            this.usrName = tela.input(24,13,"");
            this.pWord = tela.input(24,17,"");

            if(this.usrName == "".Trim() || this.pWord == "".Trim()){
                tela.botao(15,35,"Dados Obrigatórios",ConsoleColor.Red);
                Console.ReadKey();
            }else{
                this.op = tela.input(23,23,"Opção: ");

                if(this.op == "1"){
                    bool achou = false;
                    for (int x=0; x < this.Dados.Count; x++){
                        if ( this.Dados[x].user == this.usrName )
                        {
                            achou = true;
                            this.posConta = x;
                            break;
                        }
                    }
                    if(achou){
                        tela.botao(15,30,"Nome de usuário indisponível!",ConsoleColor.Red);
                        Console.ReadKey();
                    }else{
                        tela.telaCadastro();
                        tela.centralizar(11,24,24,this.usrName);
                        tela.centralizar(23,24,24,this.pWord);

                        this.name = tela.input(24,15,"");
                        this.birth = tela.input(24,19,"");
                        
                        Regex dataPadrao = new Regex("^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$");

                        if(!dataPadrao.IsMatch(this.birth)){
                            tela.botao(15,35,"Formato de data inválido!",ConsoleColor.Red);
                            Console.ReadKey();
                        }else{
                            if(this.name == "".Trim() || this.birth == "".Trim()){
                                tela.botao(15,35,"Dados Obrigatórios",ConsoleColor.Red);
                                Console.ReadKey();
                            }else{
                                this.op = tela.input(23,25,"Opção: ");

                                if(this.op == "1"){
                                    Dados.Add(new Conta(this.name, this.usrName, this.pWord, this.birth));
                                    tela.botao(15,28,$"{Dados[Dados.Count-1].infoConta()}",ConsoleColor.Green);
                                    Console.ReadKey();
                                }else{
                                    tela.telaLogin();
                                }
                            
                            }
                        }
                    }
                }else if(this.op == "2"){
                    bool achou = false;
                    for (int x=0; x < this.Dados.Count; x++){
                        if ( this.Dados[x].user == this.usrName && this.Dados[x].password == this.pWord )
                        {
                            achou = true;
                            this.posConta = x;
                            break;
                        }
                    }

                    if(achou){
                        this.navegacao();
                    }else{
                        Console.ForegroundColor = ConsoleColor.Red;
                        tela.botao(15,30,"Usuário ou senha incorretos",ConsoleColor.Red);
                        Console.ReadKey();
                    }
                }else{
                    tela.botao(15,38,"Opção Inválida",ConsoleColor.Yellow);
                    Console.ReadKey();
                }
            }
        }
    }

    public void navegacao(){
        while(op != "0"){
            tela.montarTelaSistema();
            tela.centralizar(1,2,2,"Você está na Home,");
            tela.centralizar(2,2,2,$"{this.usrName}!(⌐■_■)");
            int x = 0;

            foreach(var conta in Dados){
                foreach(var item in conta.tweets){
                    tela.montaTweet(9+7*x, 24, conta.user, item);
                    x++;
                }
            }

            this.op = tela.input(3,18,"Opção: ");
            
            if(op == "2"){
                tela.montarTelaSistema();
                tela.limparArea(23,2,87,7);
                tela.centralizar(1,2,2,"Página do Perfil");

                for(x = 0; x <=Dados[this.posConta].infoPerfil.Count-1; x++){
                    tela.centralizar(2+x,24,24,Dados[this.posConta].infoPerfil[x]);
                }

                x = 0;
                foreach(var item in Dados[posConta].tweets){
                    tela.montaTweet(9+7*x, 24, this.usrName, item);
                    x++;
                }

                tela.centralizar(7,3,3,"1 - Editar");
                tela.centralizar(10,3,3,"2 - ExcluirTweet");
                tela.centralizar(13,3,3,"3 - ExcluirConta");

                this.op = tela.input(3,18,"Opção: ");

                if(op == "1"){
                    //faço dps mó preguiça kkj
                }else if(op == "2"){
                    tela.moldura(25,10,60,18,ConsoleColor.DarkGray);
                    tela.centralizar(12,15,60,"Tem Certeza?");
                    tela.botao(14,30,"1 - Sim",ConsoleColor.Green);
                    tela.botao(14,45 ,"2 - Não",ConsoleColor.Red);

                    this.op = tela.input(40,17,"Opção: ");

                    if(op == "1"){
                        if(Dados[posConta].tweets.Count > 0){
                            Dados[posConta].tweets.RemoveAt(Dados[posConta].tweets.Count-1);
                            tela.botao(17,40,"Sucesso!",ConsoleColor.Green);
                            Console.ReadKey();
                        }
                    }else if(op == "2"){
                        tela.botao(17,40,"Voltando...",ConsoleColor.Yellow);
                        Console.ReadKey();
                    }
                }
                
            }else if (op == "3"){
                tela.limparArea(24,3,85,6);

                this.msg = tela.input(24,3,"");
                this.priv = tela.input(24,7,"Aparecer para Todos ou Privado(T/P):");

                Dados[posConta].tweetar(this.msg,DateTime.Now,this.priv);
            }
        }
    }
}