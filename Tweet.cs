class Tweet
{
    // propriedades
    public string mensagem;
    public DateTime data;
    public string privacidade;
    public List<string> tweet = new List<string>();


    // método construtor
    public Tweet(string msg, DateTime dat, string priv){
        int start = 0;
        int end = 60;
        this.mensagem = msg;
        this.data = dat;
        this.privacidade = priv;
        
        if(this.mensagem.Count() >= end){
            tweet.Add(this.mensagem.Substring(start,end));
            start+=60;
            end+=60;
        }else{
            tweet.Add(this.mensagem);
        }
    }
}