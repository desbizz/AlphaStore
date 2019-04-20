import { Supplier } from './supplier';
import { KeyValuePair } from './keyvaluepair';


export interface Product {
    id: number;
    categories: KeyValuePair;
    priceBuy: string;
    priceSell: string;
    supplier: Supplier;

}
export interface SaveProduct {

    id: number;
    categoryId: number;
    priceBuy: string;
    priceSell: string;
    supplierId: number;
    }
