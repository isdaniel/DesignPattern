use std::f64::consts::PI;
trait Shape {
    fn radius(&self) -> f64;
    fn area(&self) -> f64;
}

struct Square {
    side: f64,
}
impl Shape for Square {
    fn radius(&self) -> f64 {
        self.side / 2.0 * (2.0_f64).sqrt()
    }
    fn area(&self) -> f64 {
        self.side * self.side
    }
}

struct Round {
    radius: f64,
}

impl Round {
    fn area(&self) -> f64 {
       PI * self.radius * self.radius
    }

    fn fit(&self, other: &dyn Shape) -> bool {
        self.radius >= other.radius()
    }

    fn get_fitting_area(&self, other: &dyn Shape) -> Option<f64> {
        if self.fit(other) {
            Some(other.area())
        } else {
            None
        }
    }
}


#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_round_fit_square() {
        let round = Round { radius: 5.0 };
        let square = Square { side: 7.0 };
        assert!(round.fit(&square));
    }

    #[test]
    fn test_round_notfit_square() {
        let round = Round { radius: 5.0 };
        let square = Square { side: 8.0 };
        assert!(!round.fit(&square));
    }

    #[test]
    fn test_round_get_fitting_area() {
        let round = Round { radius: 5.0 };
        let square = Square { side: 7.0 };
        assert_eq!(round.get_fitting_area(&square), Some(square.area()));
    }

    #[test]
    fn test_round_get_fitting_area_none() {
        let round = Round { radius: 5.0 };
        let square = Square { side: 8.0 };
        assert_eq!(round.get_fitting_area(&square), None);
    }
}
