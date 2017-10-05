export class ProductCategory {
    public Name: string;
    public Id: number = 0;
    public ParentId: number;
    public HasChild: false;
    public PropertyInProductCategories:any[];
}