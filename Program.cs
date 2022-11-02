Interface Interface = new Interface();
Sistema sistema = new Sistema(Interface);

sistema.cadastroConta();
//Interface.telaCadastro();

// Conta conta = new Conta("lucas", "123");
// Console.WriteLine(conta.infoConta());
// Console.ReadKey();

// conta.tweetar("Hello World", DateTime.Now, "PB");
// Console.Write($"{conta.tweets[0].mensagem}\n Publicado:{conta.tweets[0].data.ToShortDateString()}\n Privacidade: {conta.tweets[0].privacidade}");

Console.ReadKey();
Console.Clear();