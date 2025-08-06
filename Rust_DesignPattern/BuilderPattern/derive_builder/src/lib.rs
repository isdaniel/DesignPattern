use proc_macro::TokenStream;
use quote::quote;
use syn::{parse_macro_input, Data, DeriveInput};
use syn::__private::TokenStream2;

fn map_fields<F>(fields: &syn::Fields, func: F) -> TokenStream2
where
    F: Fn(&syn::Field) -> TokenStream2
{
    TokenStream2::from_iter(
        fields.iter().map(func)
    )
}

#[proc_macro_derive(Builder)]
pub fn derive_builder(input: TokenStream) -> TokenStream {
    let input = parse_macro_input!(input as DeriveInput);
    let ident = &input.ident;
    let builder_ident = syn::Ident::new(&format!("{}Builder", ident), ident.span());

    if let Data::Struct(data_struct) = input.data {
        let builder_fields = map_fields(&data_struct.fields, |f| {
            let ident = &f.ident;
            let ty = &f.ty;
            quote! {
                #ident: Option<#ty>,
            }
        });

        let builder_set_methods = map_fields(&data_struct.fields, |f| {
            let ident = &f.ident;
            let ty = &f.ty;
            quote! {
                pub fn #ident(mut self, #ident: #ty) -> Self {
                    self.#ident = Some(#ident);
                    self
                }
            }
        });

        let builder_init_fields = map_fields(&data_struct.fields, |f| {
            let ident = &f.ident;
            quote! {
                #ident: self.#ident.unwrap_or_default(),
            }
        });

        return quote!(
            #[derive(Default)]
            pub struct #builder_ident {
                #builder_fields
            }

            impl #builder_ident {
                #builder_set_methods

                pub fn build(self) -> Result<#ident, ()> {
                    Ok(#ident {
                        #builder_init_fields
                    })
                }
            }

            impl #ident {
                pub fn builder() -> #builder_ident {
                    #builder_ident::default()
                }
            }
        ).into();
    };

    TokenStream::from(quote!())
}
