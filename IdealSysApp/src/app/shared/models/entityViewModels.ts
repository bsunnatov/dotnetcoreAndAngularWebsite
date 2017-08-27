export class DynamicPropertyViewModel
{
    public Value: string;
    public Key: string;
    public DynamicPropertyValues: DynamicPropertyValueViewModel[]
}
export class DynamicPropertyValueViewModel {
    public Value: string;
    public Key: string;
    public DynamicPropertyId: number;
}