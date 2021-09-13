import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeMoviesComponent } from './welcome-movies.component';

describe('WelcomeMoviesComponent', () => {
  let component: WelcomeMoviesComponent;
  let fixture: ComponentFixture<WelcomeMoviesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomeMoviesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeMoviesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
