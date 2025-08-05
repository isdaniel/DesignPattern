use BridgePattern::{BlueColor, GreenColor, RedColor, NickBag, NickHat, NickShirt, ObjectBase};

fn main() {
    // Create color instances
    let blue = BlueColor;
    let green = GreenColor;
    let red = RedColor;

    // Create objects with different colors
    let blue_bag = NickBag::new(blue);
    let green_hat = NickHat::new(green);
    let red_shirt = NickShirt::new(red);

    // Demonstrate the bridge pattern in action
    println!("{}", blue_bag.get_object());
    println!("{}", green_hat.get_object());
    println!("{}", red_shirt.get_object());

    // Show flexibility - any color with any object
    let red_bag = NickBag::new(RedColor);
    let blue_hat = NickHat::new(BlueColor);

    println!("{}", red_bag.get_object());
    println!("{}", blue_hat.get_object());
}
