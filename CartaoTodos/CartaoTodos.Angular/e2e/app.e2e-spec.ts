import { CartaoTodos.AngularPage } from './app.po';

describe('cartao-todos.angular App', function() {
  let page: CartaoTodos.AngularPage;

  beforeEach(() => {
    page = new CartaoTodos.AngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
