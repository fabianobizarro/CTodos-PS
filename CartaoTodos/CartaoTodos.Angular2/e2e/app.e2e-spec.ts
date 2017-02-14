import { CartaoTodosPage } from './app.po';

describe('cartao-todos App', function() {
  let page: CartaoTodosPage;

  beforeEach(() => {
    page = new CartaoTodosPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
