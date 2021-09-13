import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeforeLoginNavbarComponent } from './before-login-navbar.component';

describe('BeforeLoginNavbarComponent', () => {
  let component: BeforeLoginNavbarComponent;
  let fixture: ComponentFixture<BeforeLoginNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BeforeLoginNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BeforeLoginNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
