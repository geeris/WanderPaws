import { Component } from '@angular/core';
import { FooterLinkList } from '../../../shared/models/footer-link-list.model';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {
  footerLinks: FooterLinkList[] = [
    {
      href: '',
      label: 'Link 1'
    },
    {
      href: '',
      label: 'Link 2'
    },
    {
      href: '',
      label: 'Link 3'
    }
  ];

  socialNetworkLinks: FooterLinkList[] = [
    {
      href: '#',
      icon: 'facebook'
    },
    {
      href: '#',
      icon: 'twitter'
    },
    {
      href: '#',
      icon: 'instagram'
    }
  ];
}
