import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountTitleComponent } from './count-title.component';

describe('CountTitleComponent', () => {
  let component: CountTitleComponent;
  let fixture: ComponentFixture<CountTitleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountTitleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountTitleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
