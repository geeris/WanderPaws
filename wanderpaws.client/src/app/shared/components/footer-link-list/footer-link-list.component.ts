import { Component, Input } from '@angular/core';
import { FooterLinkList } from '../../models/footer-link-list.model';

@Component({
  selector: 'app-footer-link-list',
  templateUrl: './footer-link-list.component.html',
  styleUrl: './footer-link-list.component.css'
})
export class FooterLinkListComponent {
  @Input() links: FooterLinkList[] = [];
}
