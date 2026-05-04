# Padrões de Projeto

## Instruções

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
