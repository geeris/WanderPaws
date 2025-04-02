export interface GetCategoriesQuery {

}

export interface CreateCategoryCommand {
    name: string;
    type: string;
    parentId: number | null;
}

export interface DeleteCategoryCommand {
    id: number;
}

export interface CategoryDto {
    id: number;
    type: string;
    name: string;
    parentId: number | null;
    isPredefined: boolean;
    children: CategoryDto[]
}

export enum CategoryType {
    Expense = 0,
    Income = 1
}