using AlphaStore.Entities;
using AlphaStore.Recources;
using AlphaStore.SaveRecources;
using AutoMapper;

namespace AlphaStore.MappingProfile
{
    public class MappingProfile :Profile
    {
         /////////////////Api To Domain
    public MappingProfile(){
        
             CreateMap<SaveProductResources, Product>()
             .ForMember(f => f.Id, opt => opt.Ignore());

                CreateMap<SaveStockPurchaseResources, StockPurchase>()
             .ForMember(f => f.Id, opt => opt.Ignore());

                CreateMap<SaveOrderResources, Order>()
             .ForMember(f => f.Id, opt => opt.Ignore());

                CreateMap<CategoryResources, Category>()
             .ForMember(f => f.Id, opt => opt.Ignore());

                CreateMap<CustomerResources, Customer>()
             .ForMember(f => f.Id, opt => opt.Ignore());

                CreateMap<QuanttityResourses, Quantity>()
             .ForMember(f => f.Id, opt => opt.Ignore());

                CreateMap<StaffResources, Staff>()
             .ForMember(f => f.Id, opt => opt.Ignore());

                CreateMap<SupplierResources, Supplier>()
             .ForMember(f => f.Id, opt => opt.Ignore());

            






            ///////////////////////////////////////////////////////////////////////////////////////////

            //////Domain To Api
           
                 CreateMap<Product, ProductResources>();
                 CreateMap<StockPurchase, StockPurchaseResources>();
                 CreateMap<Order, OrderResources>();
                 CreateMap<Category, CategoryResources>();
                 CreateMap<Customer, CustomerResources>();
                 CreateMap<Quantity, QuanttityResourses>();
                 CreateMap<Staff, StaffResources>();
                 CreateMap<Store, StoreResources>();
                 CreateMap<Supplier, SupplierResources>();

        }
    }
}