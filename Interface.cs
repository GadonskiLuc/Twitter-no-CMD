class Interface{
    private ConsoleColor texto, fundo;
    private string[] caractere = {"═","║","╔","╚","╗","╝","╟","╢","╤","╧"};
    

    public Interface(   ConsoleColor txt = ConsoleColor.White,
                        ConsoleColor fnd = ConsoleColor.Black){
        this.texto = txt;
        this.fundo = fnd;
        this.configInterface();
    }

    public void configInterface(){
        Console.BackgroundColor = this.fundo;
        Console.ForegroundColor = this.texto;
        Console.Clear();
    }

    public void montarTelaSistema(){
        this.moldura(0, 0, 88, Console.WindowHeight-1, ConsoleColor.DarkBlue);
        this.linhaVer(21, 0,Console.WindowHeight-1);
        this.linhaHor(8, 21, 88);
        this.centralizar(1,24,24,"Twitter\t\t\t\t\t\t\tPT-BR");
        this.montarMenu(2,6);

        this.moldura(23,2,86,7,ConsoleColor.DarkGray);
        this.centralizar(3,25,25,"O que ta rolando?");

        this.centralizar(Console.WindowHeight-2,2,2,"By: Lucas Gadonski");
    }

    private void bordaVertical(int li, int lf, int ci, int cf){
        int col;
        for (col = ci; col <= cf; col++){
            Console.SetCursorPosition(col, li);
            Console.Write(caractere[0]);
            Console.SetCursorPosition(col, lf);
            Console.Write(caractere[0]);
        }
    }
    public void moldura(int ci, int li, int cf, int lf, ConsoleColor cor){
        int col, lin;
        Console.ForegroundColor = cor;
        Console.BackgroundColor = ConsoleColor.Black;

        this.limparArea(ci, li, cf, lf);

        this.bordaVertical(li,lf,ci,cf);

        for (lin = li; lin <= lf; lin++){
            Console.SetCursorPosition(ci, lin);
            Console.Write(caractere[1]);
            Console.SetCursorPosition(cf, lin);
            Console.Write(caractere[1]);
        }

        Console.SetCursorPosition(ci, li); Console.Write(caractere[2]);
        Console.SetCursorPosition(ci, lf); Console.Write(caractere[3]);
        Console.SetCursorPosition(cf, li); Console.Write(caractere[4]);
        Console.SetCursorPosition(cf, lf); Console.Write(caractere[5]);
    }


    public void limparArea(int ci, int li, int cf, int lf){
        int col, lin;

        for (col = ci; col <= cf; col++){
            for (lin = li; lin <= lf; lin++){
                
                Console.SetCursorPosition(col, lin);
                Console.Write(" ");
            }
        }
    }
    
    public void linhaHor(int lin, int ci, int cf){
        int col;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        // traça a linha
        for (col = ci; col <= cf; col++){
            Console.SetCursorPosition(col, lin);
            Console.Write(caractere[0]);
        }
        // arruma as pontas
        Console.SetCursorPosition(ci, lin);
        Console.Write(caractere[6]);
        Console.SetCursorPosition(cf, lin);
        Console.Write(caractere[7]);
    }

    public void linhaVer(int col, int li, int lf){
        int lin;
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        for (lin = li; lin < lf; lin++){
            Console.SetCursorPosition(col,lin);
            Console.Write(caractere[1]);
        }
        Console.SetCursorPosition(col,li);
        Console.Write(caractere[8]);
        Console.SetCursorPosition(col,lf);
        Console.Write(caractere[9]);
    }

    public void centralizar(int lin, int ci, int cf, string msg){
        int col;
        Console.ForegroundColor = ConsoleColor.White;
        col = ci+((cf-ci)/2);
        Console.SetCursorPosition(col,lin);
        Console.Write(msg);
    }

    public void telaLogin(){
        this.moldura(0, 0, 88, Console.WindowHeight-1,ConsoleColor.DarkBlue);
        //janela de login
        this.moldura(20,6,70,25,ConsoleColor.DarkBlue);
        this.linhaHor(10,20,70);
        this.centralizar(8,17,70,"Login");

        //inputs
        Console.SetCursorPosition(23,11);
        Console.Write("Insira o nome de Usuário");
        this.moldura(23,12,67,14,ConsoleColor.DarkBlue);

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(23,15);
        Console.Write("Insira sua Senha");
        this.moldura(23,16,67,18,ConsoleColor.DarkBlue);

        //botoes
        this.botao(20,23,"1 - Criar Conta",ConsoleColor.DarkBlue);
        this.botao(20,49, "2 - Fazer Login",ConsoleColor.DarkBlue);
    }

    public void telaCadastro(){
        // this.moldura(0, 0, 88, Console.WindowHeight-1,ConsoleColor.DarkBlue);
        //janela de login
        this.moldura(15,4,75,30,ConsoleColor.DarkBlue);
        this.linhaHor(8,15,75);
        this.centralizar(6,13,70,"Cadastro");

        //inputs
        Console.SetCursorPosition(23,9);
        Console.Write("Insira seu nome de usuario");
        this.moldura(23,10,67,12,ConsoleColor.DarkBlue);

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(23,13);
        Console.Write("Insira seu nome");
        this.moldura(23,14,67,16,ConsoleColor.DarkBlue);

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(23,17);
        Console.Write("Insira sua data de nascimento(dd/mm/aaaa)");
        this.moldura(23,18,67,20,ConsoleColor.DarkBlue);

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(23,21);
        Console.Write("Insira sua Senha");
        this.moldura(23,22,67,24,ConsoleColor.DarkBlue);

        //botoes
        this.botao(26,23,"1 - Criar Conta",ConsoleColor.DarkBlue);
        this.botao(26,49," 2 - Cancelar  ",ConsoleColor.DarkBlue);
    }

    public void botao(int lin, int col, string msg, ConsoleColor cor){        

        this.moldura(col,lin,col+msg.Length+3,lin+2,cor);

        Console.SetCursorPosition(col+2,lin+1);
        Console.Write(msg);
        
    }

    public void montarMenu(int col, int lin){
        List<string> menu = new List<string>();
        menu.Add("1 - Home      ");
        menu.Add("2 - Perfil    ");
        menu.Add("3 - Tweetar   ");
        menu.Add("0 - Sair      ");

        for(int x = 0; x <= menu.Count-1; x++){
            this.botao(lin,col,menu[x],ConsoleColor.White);
            lin+=3;
        }
    }

    public string input(int col, int lin, string pergunta){
        string entrada;
        Console.ForegroundColor = ConsoleColor.White;
        
        Console.SetCursorPosition(col,lin);
        Console.Write(pergunta);
        
        entrada = Console.ReadLine();

        return entrada;
    }

    public void montaTweet(int lin, int col, string user, Tweet twtt){
        this.centralizar(lin,col,col,$"@{user} · ");
        Console.Write(twtt.data.ToShortTimeString());

        for(int x = 0; x < 3; x++){
            this.centralizar(lin+2+x,col,col, twtt.tweet[x]);
        }
        this.centralizar(lin+5,81,81,twtt.privacidade);
        this.linhaHor(lin+6,21,88);
    }
    public string LerSenha(int lin, int col){
        var pw = new System.Text.StringBuilder();
        bool caracterApagado = false;
        Console.SetCursorPosition(col,lin);

        while (true){
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key == ConsoleKey.Enter){
                Console.WriteLine();
                break;
            }

            if (deletarTexto(cki)){
                if (pw.Length != 0)
                {
                    Console.Write("\b \b");
                    pw.Length--;

                    caracterApagado = true;
                }
            }
            else{
                caracterApagado = false;
            }

            if (!caracterApagado && verificarCaracterValido(cki)){
                Console.Write('*');
                pw.Append(cki.KeyChar);
            }
        }
        return pw.ToString();
    }
    private static bool verificarCaracterValido(ConsoleKeyInfo tecla){
        if (char.IsLetterOrDigit(tecla.KeyChar) || char.IsPunctuation(tecla.KeyChar) ||
            char.IsSymbol(tecla.KeyChar))
        {
            return true;
        }else{
            return false;
        }

    }

    private static bool deletarTexto(ConsoleKeyInfo tecla){
        if (tecla.Key == ConsoleKey.Backspace || tecla.Key == ConsoleKey.Delete)
            return true;
        else
            return false;
    }
}