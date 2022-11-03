using System.Text.RegularExpressions;
class Sistema{
    private Interface tela;
    private string usrName;
    private string pWord;
    private string name;
    private string birth;
    private string bio;
    private List<Conta> Dados = new List<Conta>();
    private string op;
    private string msg1,msg2,msg3;
    private string priv;
    private int posConta = 0;

    public Sistema (Interface tela){
        this.tela = tela;
        this.Dados.Add(new Conta("lucas matheus","luc","123","30/06/2004"));
        this.Dados.Add(new Conta("teste","teste","123","30/06/2004"));
    }

    public void cadastroConta(){
        while(true){
            tela.telaLogin();
            
            this.usrName = tela.input(24,13,"");
            this.pWord = tela.LerSenha(17,24);

            this.op = tela.input(23,23,"Opção(0 - Sair): ");
            
            if(op == "0"){
                    tela.botao(15,30,"Até mais :)",ConsoleColor.Yellow);
                    break;;
            }

            if(this.usrName == "".Trim() || this.pWord == "".Trim()){
                tela.botao(15,35,"Dados Obrigatórios",ConsoleColor.Red);
                Console.ReadKey();
            }else{
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
                        for(int x = 0; x <this.pWord.Count(); x++){
                            tela.centralizar(23,24+x,24+x,"•");
                        }

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
                                    tela.botao(15,28,"Voltando...",ConsoleColor.Yellow);
                                    Console.ReadKey();
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
                    if(item.privacidade == "public"){
                        tela.montaTweet(9+7*x, 24, conta.user, item);
                        x++;
                    }
                }
            }
            foreach(var item in Dados[posConta].tweets){
                if(item.privacidade == "priv"){
                    tela.montaTweet(9+7*x, 24, this.usrName, item);
                }
            }

            this.op = tela.input(3,18,"Opção: ");
            
            if(op == "2"){
                tela.montarTelaSistema();
                tela.limparArea(23,2,87,7);
                tela.centralizar(1,2,2,"Página do Perfil");

                for(x = 0; x <=Dados[this.posConta].infoPerfil.Count-1; x++){
                    tela.centralizar(3+x,24,24,Dados[this.posConta].infoPerfil[x]);
                }

                x = 0;
                foreach(var item in Dados[posConta].tweets){
                    tela.montaTweet(9+7*x, 24, this.usrName, item);
                    x++;
                }

                tela.centralizar(7,3,3,"1 - Editar");
                tela.centralizar(10,3,3,"2 - ExcluirTweet");
                tela.centralizar(13,3,3,"3 - ExcluirConta");
                tela.centralizar(16,3,3,"4 - Voltar");

                this.op = tela.input(3,18,"Opção: ");

                if(op == "1"){
                    string antUser = Dados[posConta].user;
                    string antName = Dados[posConta].name;
                    string antBio = Dados[posConta].bio;

                    tela.telaCadastro();
                    tela.centralizar(17,23,23,"Insira sua Bio(max 60 caracteres)        ");
                    tela.botao(26,23,"1 - Editar Dados",ConsoleColor.DarkBlue);

                    this.usrName = tela.input(24,11,"");
                    
                    bool achou = false;
                    for (x=0; x < this.Dados.Count; x++){
                        if ( this.Dados[x].user == this.usrName){
                            achou = true;
                            break;
                        }
                    }
                    if(achou){
                        tela.botao(15,35,"Nome de Usuário já utilizado!",ConsoleColor.Red);
                        this.usrName = antUser;
                        Console.ReadKey();
                    }else{
                        this.name = tela.input(24,15,"");  
                        this.bio = tela.input(24,19,"");

                        if(this.usrName.Trim() == ""){
                            this.usrName = antUser;
                        }
                        if(this.name.Trim() == ""){
                            this.name = antName;
                        }
                        if(this.bio.Trim() == ""){
                            this.bio = antBio;
                        }

                        this.pWord = tela.LerSenha(23,24);
                        
                        if(this.pWord != Dados[posConta].password){
                            tela.botao(15,35,"Senha Incorreta!",ConsoleColor.Red);
                            Console.ReadKey();
                        }else{

                            this.op = tela.input(23,25,"Opção: ");

                            if(this.op == "1"){
                                Dados[posConta].editarDados(this.usrName,this.name,this.bio);
                                tela.botao(15,28,"Dados alterados com Sucesso!",ConsoleColor.Green);
                                Console.ReadKey();
                            }else{
                                this.usrName = antUser;
                                this.name = antName;
                                tela.botao(15,28,"Voltando...",ConsoleColor.Yellow);
                                Console.ReadKey();
                            }
                        }
                    }
                    
                    
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
                        }else{
                            tela.botao(17,40,"Você não possui Tweets!",ConsoleColor.Red);
                            Console.ReadKey();
                        }
                    }else if(op == "2"){
                        tela.botao(17,40,"Voltando...",ConsoleColor.Yellow);
                        Console.ReadKey();
                    }
                }else if(op == "3"){
                    tela.moldura(25,10,60,18,ConsoleColor.DarkGray);
                    tela.centralizar(12,15,60,"Tem Certeza?");
                    tela.botao(14,30,"1 - Sim",ConsoleColor.Red);
                    tela.botao(14,45 ,"2 - Não",ConsoleColor.Cyan);

                    this.op = tela.input(40,17,"Opção: ");

                    if(op == "1"){
                        Dados.RemoveAt(posConta);
                        tela.botao(17,40,"Até mais... ಥ_ಥ",ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                    }else if(op == "2"){
                        tela.botao(17,40,"Voltando...",ConsoleColor.Yellow);
                        Console.ReadKey();
                    }
                }else if(op == "4"){
                    tela.botao(17,40,"Voltando...",ConsoleColor.Yellow);
                    Console.ReadKey();
                }
                
            }else if (op == "3"){
                tela.limparArea(24,3,85,6);

                this.msg1 = tela.input(24,3,"");
                this.msg2 = tela.input(24,4,"");
                this.msg3 = tela.input(24,5,"");

                this.priv = tela.input(24,7,"Aparecer para Todos ou Privado(T/P):");

                if(this.priv.ToUpper() =="T" || this.priv.ToUpper() =="P"){
                    
                    Dados[posConta].tweetar(msg1,msg2,msg3,DateTime.Now,this.priv);
                   
                }else{
                    tela.botao(17,40,"Entrada Inválida!",ConsoleColor.Red);
                    Console.ReadKey();
                }

            }
        }
    }
}