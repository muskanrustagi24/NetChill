import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesNavbarComponent } from './movies-navbar.component';

describe('MoviesNavbarComponent', () => {
  let component: MoviesNavbarComponent;
  let fixture: ComponentFixture<MoviesNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MoviesNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MoviesNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
