pub trait Device {
    fn name(&self) -> &str;
    fn is_enabled(&self) -> bool;
    fn enable(&mut self);
    fn disable(&mut self);
    fn volume(&self) -> u8;
    fn set_volume(&mut self, volume: u8);
}

#[derive(Clone, Debug)]
pub struct Tv {
    enabled: bool,
    volume: u8,
}

impl Tv {
    pub fn new() -> Self {
        Self {
            enabled: false,
            volume: 20,
        }
    }
}

impl Default for Tv {
    fn default() -> Self {
        Self::new()
    }
}

impl Device for Tv {
    fn name(&self) -> &str {
        "TV"
    }

    fn is_enabled(&self) -> bool {
        self.enabled
    }

    fn enable(&mut self) {
        self.enabled = true;
    }

    fn disable(&mut self) {
        self.enabled = false;
    }

    fn volume(&self) -> u8 {
        self.volume
    }

    fn set_volume(&mut self, volume: u8) {
        self.volume = volume.min(100);
    }
}

#[derive(Clone, Debug)]
pub struct Radio {
    enabled: bool,
    volume: u8,
}

impl Radio {
    pub fn new() -> Self {
        Self {
            enabled: false,
            volume: 10,
        }
    }
}

impl Default for Radio {
    fn default() -> Self {
        Self::new()
    }
}

impl Device for Radio {
    fn name(&self) -> &str {
        "Radio"
    }

    fn is_enabled(&self) -> bool {
        self.enabled
    }

    fn enable(&mut self) {
        self.enabled = true;
    }

    fn disable(&mut self) {
        self.enabled = false;
    }

    fn volume(&self) -> u8 {
        self.volume
    }

    fn set_volume(&mut self, volume: u8) {
        self.volume = volume.min(100);
    }
}

pub struct RemoteControl {
    device: Box<dyn Device>,
}

impl RemoteControl {
    pub fn new(device: Box<dyn Device>) -> Self {
        Self { device }
    }

    pub fn power(&mut self) {
        if self.device.is_enabled() {
            self.device.disable();
            return;
        }

        self.device.enable();
    }

    pub fn volume_up(&mut self) {
        self.device
            .set_volume(self.device.volume().saturating_add(10));
    }

    pub fn status(&self) {
        let power = if self.device.is_enabled() {
            "enabled"
        } else {
            "disabled"
        };

        println!(
            "{} is {} at volume {}",
            self.device.name(),
            power,
            self.device.volume(),
        );
    }
}

fn main() {
    let mut tv_remote = RemoteControl::new(Box::new(Tv::new()));
    let mut radio_remote = RemoteControl::new(Box::new(Radio::new()));

    tv_remote.power();
    tv_remote.volume_up();

    radio_remote.power();
    radio_remote.volume_up();
    radio_remote.volume_up();

    tv_remote.status();
    radio_remote.status();
}
