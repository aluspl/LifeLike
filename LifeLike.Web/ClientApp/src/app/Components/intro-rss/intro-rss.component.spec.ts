import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IntroRSSComponent } from './intro-rss.component';

describe('IntroRSSComponent', () => {
  let component: IntroRSSComponent;
  let fixture: ComponentFixture<IntroRSSComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IntroRSSComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IntroRSSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
