import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { CategoryDto, DeleteCategoryCommand, GetCategoriesQuery } from '../../models/category.model';
import { NotificationService } from '../../../../core/services/notification.service';
import { TreeNode } from 'primeng/api';

@Component({
  selector: 'app-categories-overview',
  templateUrl: './categories-overview.component.html',
  styleUrls: ['./categories-overview.component.css']
})
export class CategoriesOverviewComponent implements OnInit {
  data: any[] = [];

  visible: boolean = false;

  selectedCategory: CategoryDto | undefined;

  constructor(
    private categoryService: CategoryService,
    private notificationService: NotificationService
  ) {
    
  }

  // onItemClick(category: any, actionsMenu: any, event: any): void {
  //   this.selectedCategory = category;
  //   actionsMenu.toggle(event);

  //   console.log('Active category:', this.selectedCategory);
  // }

  ngOnInit(): void {
    //const query: GetCategoriesQuery = {};

    // this.categoryService.getCategories(query).subscribe({
    //   next: (data: CategoryDto[]) => {
    //     console.log(data); // You can use this data to update the component state
    //     this.data = data; // Update the data array with the fetched categories
    //   }
    // });
  }

  createCategory(): void {
    this.visible = false

    // this.categoryService.createCategory(new createcategorycommand).subscribe(
    //   (response) => {
    //     this.notificationService.showSuccess(response)

    // let command: createautidevent = this.form.getrawvalue();

    // Ažuriranje UI-a sa novim podacima (ako je potrebno)
    // this.categories.push(response.category); // Dodajte novi element u listu
    //   }
    // )
    console.log("dodavanje")
  }

  deleteCategory(): void {

    if (this.selectedCategory?.id !== undefined) {
      let command: DeleteCategoryCommand = {
        id: this.selectedCategory.id
      };

      this.categoryService.deleteCategory(command).subscribe(
        (response) => {
          this.notificationService.showSuccess(response)

          //Ažuriranje UI-a (npr. uklanjanje obrisanog elementa iz liste)
          //this.categories = this.categories.filter((category) => category.id !== response.deletedId);
        }
      )
    }
  }

  showDialog(): void {
    this.visible = true;
  }
}