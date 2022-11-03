class Tweet
{
    // propriedades
    public string msg1, msg2, msg3;
    public DateTime data;
    public string privacidade;
    
    public List<string> tweet;


    // método construtor
    public Tweet(string msg1,string msg2,string msg3, DateTime dat, string priv){

        this.msg1 = msg1;
        this.msg2 = msg2;
        this.msg3 = msg3;
        this.data = dat;

        if(priv.ToUpper() == "T"){
            this.privacidade = "public";
        }else if(priv.ToUpper() == "P"){
            this.privacidade = "priv";
        }
        this.tweets();
    }
    public void tweets(){
        this.tweet = new List<string>();
        tweet.Add(msg1);
        tweet.Add(msg2);
        tweet.Add(msg3);
    }
}