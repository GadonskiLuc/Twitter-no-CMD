class Conta{
    public string user;
    public string name;
    public string bio;
    public string password;
    public string birthDate;
    public List<string> infoPerfil = new List<string>();
    public List<Tweet> tweets = new List<Tweet>();

    public Conta(string nome, string usuario, string senha, string nasc){
        this.user = usuario;
        this.name = nome;
        this.password = senha;
        this.birthDate = nasc;
        this.bio = "Você não tem Bio";

        this.infoPerfil.Add($"@{this.user}");
        this.infoPerfil.Add(this.name);
        this.infoPerfil.Add(this.bio);
        this.infoPerfil.Add(this.birthDate);
    }

    public void editarDados(string user, string name, string bio){
        this.user = user;
        this.name = name;
        this.bio = bio;
        
        for(int x = 0; x < 4; x++){
            this.infoPerfil.RemoveAt(0);
        }
        
        this.infoPerfil.Add($"@{this.user}");
        this.infoPerfil.Add(this.name);
        this.infoPerfil.Add(this.bio);
        this.infoPerfil.Add(this.birthDate);
    }

    public string infoConta(){
        string info = "";
        
        info+="Conta de ";
        info+=this.user;
        info+=" criada com sucesso";

        return info;
    }

    public void tweetar(string msg, string msg2, string msg3, DateTime data, string priv){
        tweets.Add(new Tweet(msg,msg2,msg3, data, priv));
    }

}