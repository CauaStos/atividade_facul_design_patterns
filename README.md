# Padrões de Projeto

## Instruções

### Iterator

Rode:

```bash
cd iterator
cargo run
```

Esse exemplo cria uma struct `Playlist`, que guarda as tracks e expõe um iterador próprio via um trait chamado `PlaylistIterator`. Para fazer da playlist um iterator, chamamos o método `playlist.iter()`, ele cria o iterator, assim, podemos usar o método `.next()` para percorrer os itens um por um.

Com isso, a `Playlist` não precisa expor diretamente como os dados estão guardados por dentro. Quem usa a playlist só precisa pedir um iterator e ir chamando `.next()`, que é justamente a ideia principal do padrão.

### Bridge

Rode:

```bash
cd bridge
cargo run
```

Esse exemplo cria um controle remoto `RemoteControl` e uma interface de dispositivo chamada `Device`.

O controle remoto sabe quais ações pode fazer, como ligar/desligar e aumentar volume, mas não precisa saber se está controlando uma TV ou um rádio. Quem sabe como ligar, desligar e guardar o volume é o dispositivo que implementa `Device`.

No main, o código cria dois controles remotos usando a mesma estrutura, mas passando dispositivos diferentes:

```rust
let mut tv_remote = RemoteControl::new(Box::new(Tv::new()));
let mut radio_remote = RemoteControl::new(Box::new(Radio::new()));
```

Assim, a abstração (`RemoteControl`) fica separada da implementação (`Tv` e `Radio`), que é a ideia principal do Bridge.
