import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AfterLoginNavbarComponent } from './after-login-navbar.component';

describe('AfterLoginNavbarComponent', () => {
  let component: AfterLoginNavbarComponent;
  let fixture: ComponentFixture<AfterLoginNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AfterLoginNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AfterLoginNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
