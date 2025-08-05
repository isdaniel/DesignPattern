pub trait ColorBase {
    fn get_color(&self) -> String;
}
pub trait ObjectBase<D: ColorBase> {
    fn get_object(&self) -> String;
}

// Macro to generate color structs with ColorBase implementations
macro_rules! define_color {
    ($($color_name:ident => $color_str:expr),* $(,)?) => {
        $(
            pub struct $color_name;

            impl ColorBase for $color_name {
                fn get_color(&self) -> String {
                    $color_str.to_string()
                }
            }
        )*
    };
}

// Generate all color structs
define_color! {
    BlueColor => "Blue",
    GreenColor => "Green",
    RedColor => "Red",
}


// Macro to generate object structs with their implementations
macro_rules! define_object {
    ($($object_name:ident => $object_str:expr),* $(,)?) => {
        $(
            pub struct $object_name<D: ColorBase> {
                color: D,
            }

            impl<D: ColorBase> $object_name<D> {
                pub fn new(color: D) -> Self {
                    $object_name { color }
                }
            }

            impl<D: ColorBase> ObjectBase<D> for $object_name<D> {
                fn get_object(&self) -> String {
                    format!("{} with color: {}", $object_str, self.color.get_color())
                }
            }
        )*
    };
}

// Generate all object structs
define_object! {
    NickBag => "NickBag",
    NickHat => "NickHat",
    NickShirt => "NickShirt",
}

#[cfg(test)]
mod tests {
    use super::*;


    #[test]
    fn test_nick_bag() {
        let blue_bag = NickBag::new(BlueColor);
        assert_eq!(blue_bag.get_object(), "NickBag with color: Blue");
    }

    #[test]
    fn test_nick_hat() {
        let green_hat = NickHat::new(GreenColor);
        assert_eq!(green_hat.get_object(), "NickHat with color: Green");
    }

    #[test]
    fn test_nick_shirt() {
        let red_shirt = NickShirt::new(RedColor);
        assert_eq!(red_shirt.get_object(), "NickShirt with color: Red");
    }

    #[test]
    fn test_nick_bag_with_different_color() {
        let red_bag = NickBag::new(RedColor);
        assert_eq!(red_bag.get_object(), "NickBag with color: Red");
    }
}

//Original code structure for reference
/*
trait ColorBase {
    fn get_color(&self) -> String;
}

trait ObjectBase<D: ColorBase> {
    fn get_object(&self) -> String;
}

struct BlueColor;
struct GreenColor;
struct RedColor;

impl ColorBase for BlueColor {
    fn get_color(&self) -> String {
        "Blue".to_string()
    }
}

impl ColorBase for GreenColor {
    fn get_color(&self) -> String {
        "Green".to_string()
    }
}

impl ColorBase for RedColor {
    fn get_color(&self) -> String {
        "Red".to_string()
    }
}


struct NickBag<D: ColorBase> {
    color: D,
}
struct NickHat<D: ColorBase> {
    color: D,
}
struct NickShirt<D: ColorBase> {
    color: D,
}

impl <D: ColorBase> NickBag<D> {
    fn new(color: D) -> Self {
        NickBag { color }
    }
}

impl <D: ColorBase> NickHat<D> {
    fn new(color: D) -> Self {
        NickHat { color }
    }
}

impl <D: ColorBase> NickShirt<D> {
    fn new(color: D) -> Self {
        NickShirt { color }
    }
}

impl<D: ColorBase> ObjectBase<D> for NickBag<D> {

    fn get_object(&self) -> String {
        format!("NickBag with color: {}", self.color.get_color())
    }
}

impl<D: ColorBase> ObjectBase<D> for NickHat<D> {
    fn get_object(&self) -> String {
        format!("NickHat with color: {}", self.color.get_color())
    }
}

impl<D: ColorBase> ObjectBase<D> for NickShirt<D> {
    fn get_object(&self) -> String {
        format!("NickShirt with color: {}", self.color.get_color())
    }
}
*/
