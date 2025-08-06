use derive_builder::Builder;

#[derive(Debug, Builder)]
pub struct TestBuilder {
    executable: String,
    args: Vec<String>,
    current_dir: String,
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_builder() {
        let builder = TestBuilder::builder()
            .executable("test_executable".to_string())
            .args(vec!["arg1".to_string(), "arg2".to_string()])
            .current_dir("test_dir".to_string());
        let built = builder.build().unwrap();

        assert_eq!(built.executable, "test_executable");
        assert_eq!(built.args, vec!["arg1".to_string(), "arg2".to_string()]);
        assert_eq!(built.current_dir, "test_dir");
    }

    #[test]
    fn test_builder_with_default() {
        let builder = TestBuilder::builder()
            .executable("default_executable".to_string())
            .args(vec![])
            .current_dir("default_dir".to_string());
        let built = builder.build().unwrap();
        assert_eq!(built.executable, "default_executable");
        assert!(built.args.is_empty());
        assert_eq!(built.current_dir, "default_dir");
    }
}
