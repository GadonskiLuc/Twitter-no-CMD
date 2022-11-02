class Conta{
    public string user;
    public string name;
    public string password;
    public string birthDate;
    public List<string> infoPerfil = new List<string>();
    public List<Tweet> tweets = new List<Tweet>();

    public Conta(string nome, string usuario, string senha, string nasc){
        this.user = usuario;
        this.name = nome;
        this.password = senha;
        this.birthDate = nasc;

        this.infoPerfil.Add(this.user);
        this.infoPerfil.Add(this.name);
        this.infoPerfil.Add(this.birthDate);        
        //this.infoPerfil.Add(this.bio);
    }

    public string infoConta(){
        string info = "";
        
        info+="Conta de ";
        info+=this.user;
        info+=" criada com sucesso";

        return info;
    }

    public void tweetar(string msg, DateTime data, string priv){
        tweets.Add(new Tweet(msg, data, priv));
    }

}