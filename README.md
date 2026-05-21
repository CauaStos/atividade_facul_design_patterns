# Padrões de Projeto

## Instruções

Todos os exemplos foram refeitos em C# como projetos de console separados.

### Factory Method

Rode:

```bash
dotnet run --project factory_method
```

Ou passe a escolha direto pela linha de comando:

```bash
dotnet run --project factory_method -- email
dotnet run --project factory_method -- sms
```

Esse exemplo cria uma interface `INotification` e duas implementações concretas: `EmailNotification` e `SmsNotification`.

A classe abstrata `NotificationCreator` define o factory method `CreateNotification()`. As classes `EmailNotificationCreator` e `SmsNotificationCreator` decidem qual objeto concreto será criado.

Assim, o código principal trabalha com o criador abstrato e não precisa instanciar diretamente as notificações concretas. Essa é a ideia principal do Factory Method.

### Iterator

Rode:

```bash
dotnet run --project iterator
```

Esse exemplo cria uma classe `Playlist`, que guarda as musicas e implementa `IEnumerable<Track>`.

A classe `PlaylistIterator` implementa `IEnumerator<Track>` e controla a posicao atual da navegacao. Com isso, a playlist pode ser usada em um `foreach`, mas sem expor diretamente a lista interna.

Quem usa a playlist so precisa percorrer os itens. A forma como os dados estao guardados fica escondida, que e justamente a ideia principal do Iterator.

### Bridge

Rode:

```bash
dotnet run --project bridge
```

Esse exemplo cria um controle remoto `RemoteControl` e uma interface de dispositivo chamada `IDevice`.

O controle remoto sabe quais acoes pode fazer, como ligar/desligar e aumentar volume, mas nao precisa saber se esta controlando uma TV ou um radio. Quem sabe como ligar, desligar e guardar o volume e o dispositivo que implementa `IDevice`.

No `Main`, o codigo cria dois controles remotos usando a mesma estrutura, mas passando dispositivos diferentes:

```csharp
RemoteControl tvRemote = new(new Tv());
RemoteControl radioRemote = new(new Radio());
```

Assim, a abstracao (`RemoteControl`) fica separada da implementacao (`Tv` e `Radio`), que e a ideia principal do Bridge.
