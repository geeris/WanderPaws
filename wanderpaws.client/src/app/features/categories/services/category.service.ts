import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { CategoryDto, CreateCategoryCommand, DeleteCategoryCommand, GetCategoriesQuery } from '../models/category.model';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {
    constructor(private http: HttpClient) { }

    getCategories(query: GetCategoriesQuery): Observable<CategoryDto[]> {
        return this.http.get<CategoryDto[]>(`${environment.apiUrl}/api/category`);
    }

    createCategory(command: CreateCategoryCommand): Observable<string> {
        return this.http.post<string>(`${environment.apiUrl}/api/category/create`, command);
    }

    deleteCategory(command: DeleteCategoryCommand): Observable<string> {
        return this.http.post<string>(`${environment.apiUrl}/api/category/delete`, command)
    }
}